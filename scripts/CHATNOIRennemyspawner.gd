extends Node2D

@onready var game = get_node("/root/Game/CHATNOIRSpawner")
var ennemichat_scene := preload("res://scenes/CHATNOIRennemy.tscn")
var spawn_points := []

func _ready():
	for i in get_children():
		if i is Marker2D:
			spawn_points.append(i)

func _on_timer_timeout():
	var spawn = spawn_points[randi() % spawn_points.size()]
	var chat = ennemichat_scene.instantiate()
	chat.position = spawn.position
	
	game.add_child(chat)
	print("chat noir added")
