extends Node
class_name PauseMenu

@export var pause_menu_ui_path: NodePath
@export var resume_button_path: NodePath
@export var levels_button_path: NodePath
@export var menu_button_path: NodePath
@export var levels_scene_path: String = "res://scenes/CampaignMenu.tscn"
@export var menu_scene_path: String = "res://scenes/Menu.tscn"

static var GameIsPaused: bool = false

var _pause_menu_ui: CanvasItem = null
var _resume_button: BaseButton = null
var _levels_button: BaseButton = null
var _menu_button: BaseButton = null

func _ready() -> void:
	process_mode = Node.PROCESS_MODE_ALWAYS
	GameIsPaused = false
	if not pause_menu_ui_path.is_empty():
		_pause_menu_ui = get_node_or_null(pause_menu_ui_path) as CanvasItem
	if _pause_menu_ui != null:
		_pause_menu_ui.visible = false
		_pause_menu_ui.process_mode = Node.PROCESS_MODE_ALWAYS
	_connect_button(resume_button_path, Resume)
	_connect_button(levels_button_path, LoadLevels)
	_connect_button(menu_button_path, LoadMenu)
	get_tree().paused = false

func _unhandled_input(event: InputEvent) -> void:
	if CollisionDetection.GameOver:
		return
	if event is InputEventKey and event.pressed and not event.echo and event.keycode == KEY_ESCAPE:
		if GameIsPaused:
			Resume()
		else:
			Pause()

func Resume() -> void:
	if _pause_menu_ui != null:
		_pause_menu_ui.visible = false
	GameIsPaused = false
	get_tree().paused = false

func Pause() -> void:
	if _pause_menu_ui != null:
		_pause_menu_ui.visible = true
	GameIsPaused = true
	get_tree().paused = true

func LoadLevels() -> void:
	_change_scene(levels_scene_path)

func LoadMenu() -> void:
	_change_scene(menu_scene_path)

func _connect_button(path: NodePath, handler: Callable) -> void:
	if path.is_empty():
		return
	var button := get_node_or_null(path) as BaseButton
	if button == null:
		return
	button.process_mode = Node.PROCESS_MODE_ALWAYS
	button.pressed.connect(handler)
	if path == resume_button_path:
		_resume_button = button
	elif path == levels_button_path:
		_levels_button = button
	elif path == menu_button_path:
		_menu_button = button

func _change_scene(scene_path: String) -> void:
	if scene_path.is_empty():
		return
	ScoreSystem.score = 0
	CollisionDetection.GameOver = false
	Resume()
	PauseMenu.GameIsPaused = false
	get_tree().change_scene_to_file(scene_path)
