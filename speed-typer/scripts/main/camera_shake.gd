extends Camera2D
class_name CameraShake

var _shake_time_left: float = 0.0
var _shake_magnitude: float = 0.0
var _original_position: Vector2

func _ready() -> void:
	_update_origin()
	var viewport := get_viewport()
	if viewport != null:
		viewport.size_changed.connect(_update_origin)


func _update_origin() -> void:
	var viewport := get_viewport()
	if viewport == null:
		return
	var size := viewport.get_visible_rect().size
	_original_position = size * 0.5
	position = _original_position

func Shake(duration: float, magnitude: float) -> void:
	_shake_time_left = max(duration, 0.0)
	_shake_magnitude = abs(magnitude)
	_original_position = position

func _process(delta: float) -> void:
	if _shake_time_left > 0.0:
		_shake_time_left -= delta
		var offset := Vector2(
			randf_range(-1.0, 1.0) * _shake_magnitude,
			randf_range(-1.0, 1.0) * _shake_magnitude
		)
		position = _original_position + offset
		if _shake_time_left <= 0.0:
			position = _original_position
	else:
		position = _original_position
