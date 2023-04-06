Par rapport à l'atelier ToolDev:

J'ai repris un ancien projet pour travailler sur le tooldev, mon était de créer un outil
me permettant de créer mes propres buildings en placant des tiles de parties de building dans un éditeur
et en obtenant la coordonné des tiles pour le donner au script Building.

La scène principale est la scène SampleScene.

Tout les scripts créés dans cette atelier
sont dans le dossier "03_Tooldev".

- Alduin est le premier script qu'on a fait pour tester les GUILayout
- BuildingEditor s'ouvre dans l'onglet ProtoGridBuilding, il m'a permis de générer des prefabs du visuel
des buildings avec le nom et les coordonnés voulus, mais toujours pas de façon automatique (il était toujours
plus simple de placer les tiles dans l'onglet prefab et de rentrer manuellement les coordonnés).
- DragAndDropManipulator et les scripts UIT m'ont permis de drag and drop les tiles que je voulais pour créer
le visuel de mes buildings de façon plus naturelle. (se lance dans Window/UI Toolkit/ UI Builder)
- BuildingSizeInitiator est le script qui a fini par faire ce que je voulais. Il s'éxécute seulement dans l'éditeur
et va chercher la coordonné transform de ses enfants pour la retransmettre au script Building, me permettant
de changer automatiquement la valeur BuildingOccupation comme je le souhaitais initialement. Editer la prefab "Lab"
permet de tester ce script.