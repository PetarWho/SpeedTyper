extends Node

var Username: String = ""
var Level: int = 1
var Exp: int = 0
var TotalExp: int = 0
var AvatarImage: Texture2D
var EasyWins: int = 0
var NormalWins: int = 0
var HardWins: int = 0
var InsaneWins: int = 0
var HighScore: int = 0
var Coins: int = 0
var CampaignLevel: int = 1
var PerfectGames: int = 0
var CheatDetected: bool = false

func _ready() -> void:
	randomize()
	if Username == "":
		Username = "Player" + str(randi_range(100000000, 999999999))

func IncreaseExp(amount: int) -> void:
	TotalExp += amount
	Exp += amount
