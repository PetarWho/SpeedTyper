extends Node
class_name WordTimer

@export var word_manager_path: NodePath

static var word_fall_speed: float = 1.0
var word_delay: float = 1.0
var _next_word_time: float = 0.0
static var score_to_win: int = 0
static var exp_give: int = 0

var _time_accum: float = 0.0

func _ready() -> void:
	var diff := LevelLoader.staticDifficulty
	if diff.is_valid_int():
		var level := int(diff)
		word_fall_speed = 0.5 + float(level) / 75.0
		word_delay = 2.0 - float(level) / 175.0
		score_to_win = int(50 + ((level - 1) / 99.0) * (1500 - 50))
		if level < 100:
			exp_give = 0
		else:
			if User.CampaignLevel == 99:
				exp_give = 1000
			else:
				exp_give = 100
	else:
		# If no difficulty was set, default to "Normal" so the game has reasonable parameters.
		if diff == "":
			diff = "Normal"
		match diff:
			"Easy":
				word_fall_speed = 1.2
				word_delay = 2.0
				score_to_win = 3
				exp_give = 105
			"Normal":
				word_fall_speed = 1.4
				word_delay = 1.5
				score_to_win = 500
				exp_give = 20
			"Hard":
				word_fall_speed = 1.65
				word_delay = 1.4
				score_to_win = 1000
				exp_give = 50
			"Insane":
				word_fall_speed = 1.8
				word_delay = 1.25
				score_to_win = 2000
				exp_give = 150
			"Endless":
				word_fall_speed = 1.3
				word_delay = 1.45
				exp_give = 0
				score_to_win = 2 ** 63 - 1
			"Custom":
				word_fall_speed = GetCustomSettings.CustomSpeed
				word_delay = GetCustomSettings.CustomDelay
				score_to_win = GetCustomSettings.CustomScore
				exp_give = 0

func _process(delta: float) -> void:
	if get_tree().paused or CollisionDetection.GameOver:
		return
	_time_accum += delta
	if _time_accum >= _next_word_time:
		var manager := get_node_or_null(word_manager_path)
		if manager != null and manager.has_method("AddWord"):
			manager.AddWord()
		_next_word_time = _time_accum + word_delay
