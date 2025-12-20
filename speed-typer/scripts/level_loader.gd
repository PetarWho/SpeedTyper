extends Node
class_name LevelLoader

@export var difficulty: String = ""
static var staticDifficulty: String = ""

func LoadLevel(scene_path: String) -> void:
	staticDifficulty = difficulty
	get_tree().change_scene_to_file(scene_path)

func ExitGame() -> void:
	get_tree().quit()
