extends CharacterBody2D

@export var Speed = 200
@onready var animated_sprite = 	$AnimatedSprite2D
@export var projectile_scene: PackedScene
@export var projectile_offset := Vector2(10,0)

#event pour detecter si player tire avec espace 
func _input(event):
	if event.is_action_pressed("ui_accept"):
		shoot()
		
func shoot():
	if not projectile_scene:
		return
	
	var projectile = projectile_scene.instantiate() as Area2D
	get_parent().add_child(projectile)
	
	projectile.global_position = global_position + Vector2(projectile_offset.x * (-1 if animated_sprite.flip_h else 1), projectile_offset.y)
	projectile.direction = Vector2.LEFT if animated_sprite.flip_h else Vector2.RIGHT

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
