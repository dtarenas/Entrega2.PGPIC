# Team Ragnarok
### Segunda Entrega
##### Caso de Negocio: Plataforma de Gestión de Proyectos de Investigación Científica (PGPIC)

##### Integrantes
- Diego Alejandro Arenas Tangarife.
- Diana Milena García Galarza.

######Diagrama de base de datos resultante
![image](https://dev.azure.com/diegoarenast/d7a87b71-d240-41bf-b915-6cffdcf4c3b9/_apis/wit/attachments/d2bd048a-a9ac-4e56-92aa-9e20a0c80ef8?fileName=image.png)

######Vista preliminar del swagger con todos los métodos disponibles
![image](https://dev.azure.com/diegoarenast/d7a87b71-d240-41bf-b915-6cffdcf4c3b9/_apis/wit/attachments/320efd51-412f-4b5d-8081-7d41fdfa229b?fileName=2024-04-12%2020-59-27.gif)

###Tener en cuenta

> Antes de ejecutar la aplicación se debe modificar el archivo llamado appSettings.json en la sección **ConnectionStrings**, actualizando el servidor, usuario y clave de base de datos
```json
  "ConnectionStrings": {
    "PGPICConnection": "Server=<<Tu Servidor>>;Initial Catalog=PGPIC;Encrypt=False;User Id=<<Tu Usiario>>; Password=<<Tu Contraseña>>"
  }
```