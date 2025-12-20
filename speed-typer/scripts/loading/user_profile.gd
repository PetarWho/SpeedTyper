extends Node

@export var exp_bar_path: NodePath
@export var exp_needed_text_path: NodePath
@export var current_level_text_path: NodePath
@export var username_text_path: NodePath
@export var easy_wins_path: NodePath
@export var normal_wins_path: NodePath
@export var hard_wins_path: NodePath
@export var insane_wins_path: NodePath
@export var campaign_level_path: NodePath
@export var perfect_games_path: NodePath
@export var coin_text_path: NodePath
@export var total_exp_path: NodePath
@export var user_exp_path: NodePath

var _exp_bar: ProgressBar
var _exp_needed_text: Label
var _current_level_text: Label
var _username_text: Label
var _easy_wins: Label
var _normal_wins: Label
var _hard_wins: Label
var _insane_wins: Label
var _campaign_level: Label
var _perfect_games: Label
var _coin_text: Label
var _total_exp: Label
var _user_exp: Label

func _ready() -> void:
	SaveSystem.Load()
	if not exp_bar_path.is_empty():
		_exp_bar = get_node_or_null(exp_bar_path) as ProgressBar
	_exp_needed_text = _get_label_node(exp_needed_text_path)
	_current_level_text = _get_label_node(current_level_text_path)
	_username_text = _get_label_node(username_text_path)
	_easy_wins = _get_label_node(easy_wins_path)
	_normal_wins = _get_label_node(normal_wins_path)
	_hard_wins = _get_label_node(hard_wins_path)
	_insane_wins = _get_label_node(insane_wins_path)
	_campaign_level = _get_label_node(campaign_level_path)
	_perfect_games = _get_label_node(perfect_games_path)
	_coin_text = _get_label_node(coin_text_path)
	_total_exp = _get_label_node(total_exp_path)
	_user_exp = _get_label_node(user_exp_path)
	_update_profile()

func _get_label_node(path: NodePath) -> Label:
	if path.is_empty():
		return null
	return get_node_or_null(path) as Label

func _update_profile() -> void:
	if _username_text != null:
		_username_text.text = User.Username
	var level := LevelingSystem.GetCurrentLevel(User.TotalExp)
	if _current_level_text != null:
		_current_level_text.text = "Level %d" % level
	var exp_needed := LevelingSystem.GetExpNeeded(User.Level)
	if _exp_needed_text != null:
		_exp_needed_text.text = "%d xp for next level" % (exp_needed - User.Exp)
	if _exp_bar != null and exp_needed > 0:
		_exp_bar.value = float(User.Exp) / float(exp_needed)
	if _easy_wins != null:
		_easy_wins.text = "Easy Wins: %d" % User.EasyWins
	if _normal_wins != null:
		_normal_wins.text = "Normal Wins: %d" % User.NormalWins
	if _hard_wins != null:
		_hard_wins.text = "Hard Wins: %d" % User.HardWins
	if _insane_wins != null:
		_insane_wins.text = "INSANE Wins: %d" % User.InsaneWins
	if _campaign_level != null:
		_campaign_level.text = "Campaign Level: %s" % ("MAX" if User.CampaignLevel == 100 else str(User.CampaignLevel))
	if _perfect_games != null:
		_perfect_games.text = "Perfect Games: %d" % User.PerfectGames
	if _coin_text != null:
		_coin_text.text = str(User.Coins)
	if _total_exp != null:
		_total_exp.text = str(User.TotalExp)
	if _user_exp != null:
		_user_exp.text = str(User.Exp)
