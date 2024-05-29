# CombatSystemTest
 
This repo contains a Unity 3D project exercise aimed at developing a decoupled combat system within 48 hours. The project features sample implementations for Scriptable Objects, UnityEvents, Interfaces, etc. To access the full project, you can either clone it using git or download as zip. You can also separately download the build.zip  located at the root folder to try the output Windows build.

Libraries and Systems used:
- TextMeshPro
- Unity Navmesh
- Unity Probuilder
- Unity Scriptable Objects
- 3D Pirates Low Poly Pack:  https://assetstore.unity.com/packages/3d/environments/historic/3d-pirates-lowpoly-pack-233903



**Running the Build**

Upon launching the application, 10 capsule character templates will take in unique identities and stats, pick targets at random and shoot as often as possible until either 1 or none will remain. Hitting space bar at the end screen will reset the program.

![combat system](https://github.com/lmistades/CombatSystemTest/assets/50820284/75842202-8bc7-445d-8d01-c3b07a1c0276)


**Modifying the project**

To add more units, simply duplicate the Unit Gameobject in the hierarchy and the duplicated unit will automatically join the fight. Alternatively, users can create a new unit by dragging and dropping a Unit Prefab along with a weapon prefab slotted into the Unit's Weapon Holder.



![hierarchy](https://github.com/lmistades/CombatSystemTest/assets/50820284/2f90200d-800d-45fe-bcd4-faab7c823c41)



To perform more customization, users can modify existing Scriptable Objects or create new ones through the editor. The project is currently using pirate names and weapons but it can be easily extended by creating new assets following the set format for Units, Weapons and Bullets.
![Scriptable](https://github.com/lmistades/CombatSystemTest/assets/50820284/6aeab4fb-9a78-4be7-a401-6c5cab7d7b8b)



**Future Development**
This simple prototype can serve as a template for scaled development by further expanding on existing systems like the OnDeath UnityEvent to set different conditions when a unit is destroyed, or the IDamageable interface to handle different damage recipients and apply various effects. Apart from these, the application can also benefit from other much needed enhancements like object pooling for instantiated bullets and/or enemies, unique hash/ids for sorting large numbers of Scriptable Objects, better models and animations, post-processing effects, etc.


