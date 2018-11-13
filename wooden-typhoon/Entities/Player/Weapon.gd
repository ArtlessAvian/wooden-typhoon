extends Node2D

var angle_offset = -15
var animation_player

func _ready():
	animation_player = $AnimationPlayer
	animation_player.current_animation = "Idle"
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

func _process(delta):
	if (animation_player.current_animation == "Idle"):
		$AnimationPlayer.advance(0)
		self.angle_offset = owner.angle.angle() * 180/PI
		if (Input.is_action_just_pressed("player_swing")):
			self.angle_offset = get_global_mouse_position().angle_to_point(self.global_position) * 180 / PI
			animation_player.current_animation = "Swing"
			$AnimationPlayer.advance(0)
			animation_player.queue("Postswing")
			animation_player.queue("Idle")
	
	self.rotation_degrees += angle_offset