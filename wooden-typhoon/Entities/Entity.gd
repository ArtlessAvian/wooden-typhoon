extends KinematicBody2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
var knockback_vec = Vector2()
var i_frames = 0
var health = 10
var knockback_value = 500
var knockback_self = 300

const knockback_frame_reduction = 20

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

func _physics_process(delta):
	phys_process_workaround(delta)

func phys_process_workaround(delta):
	move_and_slide(knockback_vec)
	if (knockback_vec.length_squared() > knockback_frame_reduction * knockback_frame_reduction):
		knockback_vec *= (knockback_vec.length() - knockback_frame_reduction) / knockback_vec.length()
	else:
		knockback_vec *= 0
	
	if (i_frames > 0):
		i_frames -= 1

func _on_Hitboxes_area_entered(area):
	var got_hit = area
	while (!got_hit.has_method("respond_to_hit")):
		got_hit = got_hit.get_parent()
		
		if (got_hit == null):
			print("Houston we have a problem")
	
	if (got_hit.i_frames > 0):
		return
	
	print(str(self.get_path()) + " hits " + got_hit.get_path())
	
	self.do_hitting(got_hit)
	got_hit.respond_to_hit(self, self.calc_damage(got_hit))

func do_hitting(other_entity):
	if (other_entity.get_type() != "Projectile"):
		knockback_vec.x = knockback_self
		knockback_vec.y = 0
		knockback_vec = knockback_vec.rotated(self.global_position.angle_to_point(other_entity.global_position))
	pass

func calc_damage(other_entity):
	return 3

func respond_to_hit(other_entity, damage):
	knockback_vec.x = other_entity.knockback_value
	knockback_vec.y = 0
	knockback_vec = knockback_vec.rotated(self.global_position.angle_to_point(other_entity.global_position))
	
	health -= damage
	
	print(str(self.get_name()) + ": i have " + str(health) + " health")

func get_type():
	return "Entity"