# Team Ragnarok
### Segunda Entrega
##### Caso de Negocio: Plataforma de Gesti�n de Proyectos de Investigaci�n Cient�fica (PGPIC)

##### Integrantes
- Diego Alejandro Arenas Tangarife.
- Diana Milena Garc�a Galarza.

######Diagrama de base de datos resultante
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/f9b984a3-9089-4b4d-a22a-60caa85a0c2b)

######Vista preliminar del swagger con todos los m�todos disponibles
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/9df1c456-8436-424b-a6cf-4649ce9ea1f5)

###Tener en cuenta

> Antes de ejecutar la aplicaci�n se debe modificar el archivo llamado appSettings.json en la secci�n **ConnectionStrings**, actualizando el servidor, usuario y clave de base de datos
```json
  "ConnectionStrings": {
    "PGPICConnection": "Server=<<Tu Servidor>>;Initial Catalog=PGPIC;Encrypt=False;User Id=<<Tu Usiario>>; Password=<<Tu Contrase�a>>"
  }
```