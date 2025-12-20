extends Label
class_name CoinScript

func _process(delta: float) -> void:
	text = str(User.Coins)
