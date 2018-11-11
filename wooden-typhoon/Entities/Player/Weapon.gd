extends Node2D

var angle_offset = -15
var animation_player

func _ready():
	animation_player = $Sprite/AnimationPlayer
	animation_player.current_animation = "Idle"
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

func _process(delta):
	self.rotation_degrees = get_global_mouse_position().angle_to_point(self.global_position) * 180 / PI
	
	if (animation_player.current_animation == "Idle"):
		if (Input.is_action_just_pressed("player_swing")):
			animation_player.current_animation = "Swing"
			animation_player.queue("Postswing")
			animation_player.queue("Idle")