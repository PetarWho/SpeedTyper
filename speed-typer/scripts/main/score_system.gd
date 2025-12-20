extends Node
class_name ScoreSystem

@export var score_display_path: NodePath
@export var high_score_display_paths: Array[NodePath] = []

static var NewHighScore: bool = false
static var score: int = 0

var _score_display: Label = null
var _high_score_displays: Array[Label] = []

func _ready() -> void:
	if not score_display_path.is_empty():
		_score_display = get_node_or_null(score_display_path) as Label
	for p in high_score_display_paths:
		var n := get_node_or_null(p) as Label
		if n != null:
			_high_score_displays.append(n)
	PauseMenu.GameIsPaused = false
	SaveSystem.Load()

func _process(delta: float) -> void:
	if _score_display != null:
		_score_display.text = "Score: " + str(score)
	for l in _high_score_displays:
		if NewHighScore:
			l.text = "NEW High Score: " + str(User.HighScore)
		else:
			l.text = "Highest Score: " + str(User.HighScore)
