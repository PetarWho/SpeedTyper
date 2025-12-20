extends Label
class_name WordDisplay

func SetWord(word: String, coloring: Color) -> void:
	modulate = coloring
	text = word

func RemoveLetter() -> void:
	if text.length() > 0:
		text = text.substr(1)
	modulate = Color.RED

func RemoveWord() -> void:
	queue_free()

func _process(delta: float) -> void:
	# Stop moving when paused or game over
	if get_tree().paused or CollisionDetection.GameOver:
		return
	# Move downward over time based on global word fall speed
	position.y += WordTimer.word_fall_speed * delta * 100.0
	# Trigger game over if we fall below the bottom of the screen
	var viewport_size := get_viewport().get_visible_rect().size
	if position.y > viewport_size.y:
		CollisionDetection.GameOver = true
