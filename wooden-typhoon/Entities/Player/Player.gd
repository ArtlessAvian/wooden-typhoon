extends "../Entity.gd"

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var weapon = null
var angle = Vector2(1, 0)
var input_vector = Vector2()

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

func phys_process_workaround(delta):
	input_vector *= 0;
	if (Input.is_action_pressed("ui_up")):
		input_vector.y -= 1;
	if (Input.is_action_pressed("ui_down")):
		input_vector.y += 1;
	if (Input.is_action_pressed("ui_left")):
		input_vector.x -= 1;
	if (Input.is_action_pressed("ui_right")):
		input_vector.x += 1;
	
	if (input_vector.length_squared() > 1):
		input_vector = input_vector.normalized()
	
	move_and_slide(input_vector * 200)
	.phys_process_workaround(delta)
	
#	$Sprite.frame = input_vector.angle() / PI
#	print($Sprite.frame)
#	print(i_frames)

var walk_frames = 0

func _process(delta):
	var wanted_angle
	if (input_vector.length_squared() != 0):
		wanted_angle = input_vector
		walk_frames += 1
		
	else:
		wanted_angle = (get_global_mouse_position() - self.global_position).normalized()
		walk_frames = -1
	
#	replace with better solution
	angle = angle.linear_interpolate(wanted_angle, 0.1)
	
	var angle_eights = int(round(angle.angle() * 4 / PI + 8)) % 8
	
	$Sprite.frame = [2, 2, 0, 1, 1, 1, 3, 2][angle_eights] * 3
	$Sprite.frame += int(walk_frames % 20 < 8)
	
	if i_frames > 1:
		$Sprite.self_modulate.a = int(i_frames % 4 >= 2)

func respond_to_hit(other_entity, damage):
	i_frames = 10
	.respond_to_hit(other_entity, damage)