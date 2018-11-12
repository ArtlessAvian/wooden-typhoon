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
	if (animation_player.current_animation == "Idle"):
		$Sprite/AnimationPlayer.advance(0)
		self.rotation_degrees = owner.angle.angle() * 180/PI
		if (Input.is_action_just_pressed("player_swing")):
			self.rotation_degrees = get_global_mouse_position().angle_to_point(self.global_position) * 180 / PI
			animation_player.current_animation = "Swing"
			$Sprite/AnimationPlayer.advance(0)
			animation_player.queue("Postswing")
			animation_player.queue("Idle")