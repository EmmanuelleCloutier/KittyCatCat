extends Control

#play button 
func _on_play_pressed() -> void:
	get_tree().change_scene_to_file("res://scenes/LVL/game.tscn")
	

#quit button 
func _on_exit_pressed() -> void:
	get_tree().quit()
