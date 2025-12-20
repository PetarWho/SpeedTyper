extends Node
class_name WinMenu

@export var win_menu_ui_path: NodePath
@export var win_text_path: NodePath
@export var perfect_text_path: NodePath

static var PerfectGame: bool = false

var _win_menu_ui: CanvasItem = null
var _win_text: Label = null
var _perfect_text: CanvasItem = null

var _handled: bool = false

func _ready() -> void:
	PerfectGame = true
	ScoreSystem.score = 0
	if not win_menu_ui_path.is_empty():
		_win_menu_ui = get_node_or_null(win_menu_ui_path) as CanvasItem
	if not win_text_path.is_empty():
		_win_text = get_node_or_null(win_text_path) as Label
	if not perfect_text_path.is_empty():
		_perfect_text = get_node_or_null(perfect_text_path) as CanvasItem
	if _win_menu_ui != null:
		_win_menu_ui.visible = false
	CollisionDetection.GameOver = false
	if _perfect_text != null:
		_perfect_text.visible = false

func _process(delta: float) -> void:
	if _handled:
		return
	if ScoreSystem.score >= WordTimer.score_to_win:
		_handled = true
		User.IncreaseExp(WordTimer.exp_give)
		var current_diff := LevelLoader.staticDifficulty
		match current_diff:
			"Easy":
				User.EasyWins += 1
			"Normal":
				User.NormalWins += 1
			"Hard":
				User.HardWins += 1
			"Insane":
				User.InsaneWins += 1
		PauseMenu.GameIsPaused = true
		_Pause()
		if ScoreSystem.score > User.HighScore:
			User.HighScore = ScoreSystem.score
			ScoreSystem.NewHighScore = true
		else:
			ScoreSystem.NewHighScore = false
		if current_diff.is_valid_int():
			var level := int(current_diff)
			if User.CampaignLevel < level:
				User.CampaignLevel = level
			if _win_text != null:
				_win_text.text = "You completed campaign level %d" % level
			if PerfectGame and _perfect_text != null:
				_perfect_text.visible = true
		else:
			if _win_text != null:
				_win_text.text = "You won on %s difficulty" % current_diff
			if PerfectGame and _perfect_text != null:
				_perfect_text.visible = true
		if PerfectGame:
			User.PerfectGames += 1
		SaveSystem.Save()

func PlayAgain() -> void:
	ScoreSystem.score = 0
	CollisionDetection.GameOver = false
	get_tree().reload_current_scene()

func _Pause() -> void:
	if _win_menu_ui != null:
		_win_menu_ui.visible = true
	PauseMenu.GameIsPaused = true
