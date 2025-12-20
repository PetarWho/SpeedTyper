extends Node
class_name LevelingSystem

const BASE_EXP := 100

static func GetCurrentLevel(total_exp: int) -> int:
	var level := 1
	var remaining := total_exp
	var required := GetExpNeeded(level)
	while remaining >= required:
		remaining -= required
		level += 1
		required = GetExpNeeded(level)
	User.Exp = remaining
	User.Level = level
	SaveSystem.Save()
	return level

static func GetExpNeeded(level: int) -> int:
	var scaling_factor := 3
	return int(BASE_EXP + pow(level * scaling_factor, 1.5))
