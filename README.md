# Monopoly
NB : il y a que plateau2 qui marche:
  -pour les tests:
      appuye sur "a" -> les dés tourn -> appuye sur "espace" -> les dés s'arreterent (apre un certain temp) -> appuye sur "b"
      -> le premier piens bouge  ...
  -les problemes:
      1. il y a un probleme dans la fonction Goto qui fait que la fonction getNewPionPosition de la classe Case ne s'execute 
      pas, d'ou l'apparition d'une erreur appre un certain nombre de mouvment des pions.
      2. apre la reorganisation de l'interface en hierarchie (pour faciliter le positionnement des objets) l'espace de la camera 
      sort des l'espace du convas 
