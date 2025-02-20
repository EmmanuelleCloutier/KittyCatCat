extends CharacterBody2D


@export var speed = 200.0

func _physics_process(delta: float) -> void:
	position += Input.get_vector("ui_left", "ui_right", "ui_up","ui_down") * speed * delta
	

	move_and_slide()
