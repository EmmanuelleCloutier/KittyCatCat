extends Area2D

@export var speed := 200
var direction := Vector2.ZERO

func _process(delta):
	position += direction * speed * delta
	
func _on_body_entered(body: Node2D) -> void:
	if body.is_in_group("Enemy"):
		if body.has_method("TakeDamage"):
			print("TouchedEnnemy")
			body.TakeDamage()
	queue_free() 
