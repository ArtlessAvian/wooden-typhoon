extends Camera2D

# class member variables go here, for example:
var player
var lock_player = true

var thing = 0

func _ready():
	player = get_node("../Player")
	pass

func _process(delta):
	
#	lock_player = !Input.is_action_pressed("toggle_cam")
#	lock_player = lock_player != Input.is_action_pressed("toggle_cam")	
	
#	if !lock_player and thing < 1:
#		thing += 0.05
#	elif lock_player and thing > 0:
#		thing -= 0.05
	
	self.position = (player.position + thing * player.angle * 32 * 5)
	pass