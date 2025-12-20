extends Node
class_name LoseMenu

@export var lose_menu_ui_path: NodePath
@export var camera_shake_path: NodePath

var _lose_menu_ui: CanvasItem = null
var _camera_shake: CameraShake = null

var _handled: bool = false

func _ready() -> void:
	if not lose_menu_ui_path.is_empty():
		_lose_menu_ui = get_node_or_null(lose_menu_ui_path) as CanvasItem
	if not camera_shake_path.is_empty():
		_camera_shake = get_node_or_null(camera_shake_path) as CameraShake

func _process(delta: float) -> void:
	if _handled:
		return
	if CollisionDetection.GameOver:
		_handled = true
		if _camera_shake != null:
			_camera_shake.Shake(0.5, 16.0)
		if ScoreSystem.score > User.HighScore:
			User.HighScore = ScoreSystem.score
			ScoreSystem.NewHighScore = true
		else:
			ScoreSystem.NewHighScore = false
		PauseMenu.GameIsPaused = true
		_Pause()

func Retry() -> void:
	ScoreSystem.score = 0
	CollisionDetection.GameOver = false
	if _lose_menu_ui != null:
		_lose_menu_ui.visible = false
	get_tree().reload_current_scene()

func _Pause() -> void:
	if _lose_menu_ui != null:
		_lose_menu_ui.visible = true

func LoadLevels() -> void:
	ScoreSystem.score = 0
	CollisionDetection.GameOver = false

func LoadMenu() -> void:
	ScoreSystem.score = 0
	CollisionDetection.GameOver = false
