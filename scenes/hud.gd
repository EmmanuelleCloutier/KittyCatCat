extends Control

@export var stopwatch_label : Label
@export var score_label : Label 

var stopwatch : Stopwatch

func _ready():
	stopwatch = get_tree().get_first_node_in_group("stopwatch")
	
	if GameManager.Instance != null:
		print("gamemanager est accessible")
	else:
		print("Aucune instance de game manager trouvee")
	 

func _process(delta):
	update_stopwatch_label()
	update_score_label()
	
func update_stopwatch_label():
	stopwatch_label.text = stopwatch.time_to_string()

func update_score_label():
	#score_label.text = "Score: " + str(game_manager.GetScore())
	print("into updated score fonction")  
