extends Node

@export var stopwatch_label : Label 
@export var vielabel : Label

var stopwatch : Stopwatch
@onready var player = get_node("/root/Game/Player")

func _ready():
	stopwatch = get_tree().get_first_node_in_group("stopwatch")
	

func _process(delta): 
	updateStopwatchLabel()
	updateHealthLabel()

func updateHealthLabel():
	vielabel.text = player.health_to_string()
	
func updateStopwatchLabel():
	stopwatch_label.text = stopwatch.time_to_string()
