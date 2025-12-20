extends Control
class_name CampaignMenu

@export var levels_container_path: NodePath
@export var max_level: int = 100

func _ready() -> void:
	var container := get_node_or_null(levels_container_path) as Container
	if container == null:
		return
	for i in range(1, max_level + 1):
		var btn := CampaignLevelButton.new()
		btn.level = i
		btn.text = str(i)
		# Lock levels above the player's current campaign progress
		btn.disabled = i > User.CampaignLevel
		container.add_child(btn)
