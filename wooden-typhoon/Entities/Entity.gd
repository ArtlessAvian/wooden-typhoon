extends KinematicBody2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass


func _on_Hitboxes_area_entered(area):
	var got_hit = area
	while (!got_hit.has_method("respond_to_hit")):
		got_hit = got_hit.get_parent()
		
		if (got_hit == null):
			print("Houston we have a problem")
	
	print(str(self.get_path()) + " hits " + got_hit.get_path())
	
	got_hit.respond_to_hit("heck yes")

func respond_to_hit(args):
	print(str(self.get_name()) + ": oof ouch owie\n")

func get_type():
	return "Entity"