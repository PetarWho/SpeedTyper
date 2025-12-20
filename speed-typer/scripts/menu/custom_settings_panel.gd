extends Node

@export var speed_input_path: NodePath
@export var delay_input_path: NodePath
@export var score_input_path: NodePath
@export var play_button_path: NodePath

func _ready() -> void:
	if not play_button_path.is_empty():
		var btn := get_node_or_null(play_button_path) as Button
		if btn != null:
			btn.pressed.connect(_on_play_custom_pressed)

func _on_play_custom_pressed() -> void:
	var speed_input := get_node_or_null(speed_input_path) as LineEdit
	var delay_input := get_node_or_null(delay_input_path) as LineEdit
	var score_input := get_node_or_null(score_input_path) as LineEdit
	if speed_input == null or delay_input == null or score_input == null:
		return
	var cs := float(speed_input.text)
	var cd := float(delay_input.text)
	var csc := int(score_input.text)
	GetCustomSettings.CustomSpeed = cs
	GetCustomSettings.CustomDelay = cd
	GetCustomSettings.CustomScore = csc
	LevelLoader.staticDifficulty = "Custom"
	get_tree().change_scene_to_file("res://scenes/Main.tscn")
