extends RefCounted
class_name Word

var word: String
var _type_index: int = 0
var is_golden: bool = false

static var random_number_start: int = 1
static var random_number_end: int = 51

var _display: WordDisplay
var _gold_color: Color = Color(0.992, 0.741, 0.145)
var _normal_color: Color = Color(1.0, 0.725, 0.714)

func _init(_word: String, display: WordDisplay) -> void:
	word = _word
	_type_index = 0
	_display = display
	is_golden = _roll_is_golden()
	var color := _gold_color if is_golden else _normal_color
	_display.SetWord(word, color)

func _roll_is_golden() -> bool:
	if random_number_end <= random_number_start:
		return false
	var value := randi_range(random_number_start, random_number_end - 1)
	return value == 2

func GetNextLetter() -> String:
	if _type_index >= word.length():
		return ""
	return word.substr(_type_index, 1)

func TypeLetter() -> void:
	_type_index += 1
	_display.RemoveLetter()

func WordTyped() -> bool:
	var word_typed := _type_index >= word.length()
	if word_typed:
		ScoreSystem.score += word.length()
		_display.RemoveWord()
		if LevelLoader.staticDifficulty == "Endless":
			WordTimer.word_fall_speed *= 1.0001
		else:
			WordTimer.word_fall_speed *= 1.001
	return word_typed
