extends Node
class_name WordInput

@export var word_manager_path: NodePath

func _ready() -> void:
	set_process_input(true)

func _input(event: InputEvent) -> void:
	if event is InputEventKey and event.pressed and not event.echo:
		if PauseMenu.GameIsPaused or CollisionDetection.GameOver:
			return
		if event.keycode == KEY_ESCAPE:
			return
		var codepoint: int = event.unicode
		if codepoint <= 0:
			return
		var ch := char(codepoint)
		if ch.length() != 1:
			return
		ch = ch.to_lower()
		var manager := get_node_or_null(word_manager_path) as WordManager
		if manager != null:
			manager.TypeLetter(ch)
