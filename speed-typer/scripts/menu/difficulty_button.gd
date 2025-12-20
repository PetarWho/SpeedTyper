extends Button

@export var difficulty: String = "Normal"

func _pressed() -> void:
	LevelLoader.staticDifficulty = difficulty
	get_tree().change_scene_to_file("res://scenes/Main.tscn")
