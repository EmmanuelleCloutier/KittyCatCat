extends CharacterBody2D

@export var Speed = 200
@onready var animated_sprite = 	$AnimatedSprite2D

func _ready():
	add_to_group("Player")
	
func _physics_process(delta) -> void:
	var direction = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	
	#flip the sprite
	if direction.x > 0:
		animated_sprite.flip_h = false
	elif direction.x < 0:
		animated_sprite.flip_h = true

	#animate state check 
	if direction.x == 0 and direction.y == 0:
		if animated_sprite.animation != "idle":
			animated_sprite.play("idle")
	else:
		if animated_sprite.animation != "run":
			animated_sprite.play("run")
			
	if direction.x == 0:
		velocity.x = 0
	else:
		velocity.x = direction.x * Speed
		
	if direction.y == 0:
		velocity.y = 0
	else: 
		velocity.y = direction.y * Speed
		
	move_and_slide()


func _on_area_2d_body_entered(body: Node2D) -> void:
	print("Into player")
