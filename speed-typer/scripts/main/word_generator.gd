extends Node
class_name WordGenerator

static var WORD_LIST := [
	"table", "sun", "moon", "star", "sky", "cloud", "grass", "tree", "flower", "river",
	"ocean", "mountain", "lake", "house", "door", "window", "chair", "desk", "bed", "lamp",
	"book", "pen", "pencil", "paper", "computer", "phone", "car", "bike", "plane", "train",
	"bus", "ship", "boat", "food", "apple", "banana", "orange", "pear", "grape", "strawberry"
]

static func GetRandomWord() -> String:
	if WORD_LIST.is_empty():
		return "word"
	var index := randi_range(0, WORD_LIST.size() - 1)
	return WORD_LIST[index]
