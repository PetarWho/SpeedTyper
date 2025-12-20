extends Node
class_name WordManager

var words: Array[Word] = []
@export var word_spawner_path: NodePath

var _has_active_word: bool = false
var _active_word: Word

func AddWord() -> void:
	var spawner := get_node_or_null(word_spawner_path) as WordSpawner
	if spawner == null:
		return
	var display := spawner.SpawnWord()
	if display == null:
		return
	var w := Word.new(WordGenerator.GetRandomWord(), display)
	words.append(w)

func TypeLetter(letter: String) -> void:
	letter = letter.to_lower()
	if get_tree().paused or CollisionDetection.GameOver:
		return
	if _has_active_word:
		if letter.is_empty():
			return
		var code := letter.unicode_at(0)
		if code < 32:
			return
		if _active_word.GetNextLetter() == letter:
			_active_word.TypeLetter()
		else:
			if ScoreSystem.score > 0:
				ScoreSystem.score -= 1
			WinMenu.PerfectGame = false
	else:
		if words.is_empty():
			return
		var current_word: Word = words[0]
		for w in words:
			if w.GetNextLetter() != letter or current_word != w:
				continue
			_active_word = w
			_has_active_word = true
			w.TypeLetter()
			break
	if _has_active_word and _active_word.WordTyped():
		_has_active_word = false
		if _active_word.is_golden:
			User.Coins += _active_word.word.length()
		words.erase(_active_word)
