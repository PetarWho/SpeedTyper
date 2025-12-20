extends Button
class_name CampaignLevelButton

@export var level: int = 1

func _pressed() -> void:
	LevelLoader.staticDifficulty = str(level)
	get_tree().change_scene_to_file("res://scenes/Main.tscn")
