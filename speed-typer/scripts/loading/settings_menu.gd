extends Node

@export var volume_slider_path: NodePath
@export var fullscreen_check_path: NodePath
@export var resolution_option_path: NodePath

var _volume_slider: HSlider
var _fullscreen_check: CheckBox
var _resolution_option: OptionButton
var _resolutions: Array[Vector2i] = []

func _ready() -> void:
	_volume_slider = get_node_or_null(volume_slider_path) as HSlider
	if _volume_slider != null:
		_volume_slider.min_value = -40.0
		_volume_slider.max_value = 0.0
		_volume_slider.step = 1.0
		_volume_slider.value = 0.0
		_volume_slider.value_changed.connect(_on_volume_changed)
	_fullscreen_check = get_node_or_null(fullscreen_check_path) as CheckBox
	if _fullscreen_check != null:
		var mode := DisplayServer.window_get_mode()
		_fullscreen_check.button_pressed = mode == DisplayServer.WINDOW_MODE_FULLSCREEN or mode == DisplayServer.WINDOW_MODE_EXCLUSIVE_FULLSCREEN
		_fullscreen_check.toggled.connect(_on_fullscreen_toggled)
	_resolution_option = get_node_or_null(resolution_option_path) as OptionButton
	if _resolution_option != null:
		_setup_resolutions()

func _on_volume_changed(value: float) -> void:
	var bus := AudioServer.get_bus_index("Master")
	AudioServer.set_bus_volume_db(bus, value)

func _on_fullscreen_toggled(pressed: bool) -> void:
	if pressed:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_FULLSCREEN)
	else:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)

func _setup_resolutions() -> void:
	_resolutions = [
		Vector2i(1280, 720),
		Vector2i(1600, 900),
		Vector2i(1920, 1080),
	]
	_resolution_option.clear()
	var current_size := DisplayServer.window_get_size()
	var current_index := 0
	for i in range(_resolutions.size()):
		var res := _resolutions[i]
		var label := "%dx%d" % [res.x, res.y]
		_resolution_option.add_item(label)
		if res == current_size:
			current_index = i
	_resolution_option.selected = current_index
	_resolution_option.item_selected.connect(_on_resolution_selected)

func _on_resolution_selected(index: int) -> void:
	if index < 0 or index >= _resolutions.size():
		return
	var res := _resolutions[index]
	DisplayServer.window_set_size(res)
