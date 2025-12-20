extends Button

@export var scene_path: String = ""
@export var quit_on_empty: bool = false

func _pressed() -> void:
	if scene_path != "":
		get_tree().change_scene_to_file(scene_path)
	elif quit_on_empty:
		get_tree().quit()
