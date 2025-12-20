extends Node
class_name SaveSystem

const SAVE_PATH := "user://save.cfg"

static func Save() -> void:
	var cfg := ConfigFile.new()
	cfg.set_value("user", "HighScore", User.HighScore)
	cfg.set_value("user", "Coins", User.Coins)
	cfg.set_value("user", "Exp", User.Exp)
	cfg.set_value("user", "TotalExp", User.TotalExp)
	cfg.set_value("user", "Level", User.Level)
	cfg.set_value("user", "EasyWins", User.EasyWins)
	cfg.set_value("user", "NormalWins", User.NormalWins)
	cfg.set_value("user", "HardWins", User.HardWins)
	cfg.set_value("user", "InsaneWins", User.InsaneWins)
	cfg.set_value("user", "Username", User.Username)
	cfg.set_value("user", "PerfectGames", User.PerfectGames)
	cfg.set_value("user", "CampaignLevel", User.CampaignLevel)
	cfg.save(SAVE_PATH)

static func Load() -> void:
	var cfg := ConfigFile.new()
	var err := cfg.load(SAVE_PATH)
	if err != OK:
		return
	User.HighScore = int(cfg.get_value("user", "HighScore", User.HighScore))
	User.Coins = int(cfg.get_value("user", "Coins", User.Coins))
	User.Exp = int(cfg.get_value("user", "Exp", User.Exp))
	User.TotalExp = int(cfg.get_value("user", "TotalExp", User.TotalExp))
	User.Level = int(cfg.get_value("user", "Level", User.Level))
	User.EasyWins = int(cfg.get_value("user", "EasyWins", User.EasyWins))
	User.NormalWins = int(cfg.get_value("user", "NormalWins", User.NormalWins))
	User.HardWins = int(cfg.get_value("user", "HardWins", User.HardWins))
	User.InsaneWins = int(cfg.get_value("user", "InsaneWins", User.InsaneWins))
	User.Username = str(cfg.get_value("user", "Username", User.Username))
	User.PerfectGames = int(cfg.get_value("user", "PerfectGames", User.PerfectGames))
	User.CampaignLevel = int(cfg.get_value("user", "CampaignLevel", User.CampaignLevel))
