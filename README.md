# Team Ragnarok
### Segunda Entrega
##### Caso de Negocio: Plataforma de Gestión de Proyectos de Investigación Científica (PGPIC)

##### Integrantes
- Diego Alejandro Arenas Tangarife.
- Diana Milena García Galarza.

##### URLs públicas

- [API](https://entrega2pgpic.azurewebsites.net/swagger/index.html)
- [WEB](https://pgpicweb.azurewebsites.net/)


##### Diagrama de base de datos resultante (Identity y Proyecto)
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/eb69df38-932f-48df-bf53-9b751a89cf69)


##### Vista preliminar del swagger con todos los métodos disponibles (Antes de automatizar despliegues por medio de pipeline)
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/9df1c456-8436-424b-a6cf-4649ce9ea1f5)

### Tener en cuenta (Solo para ejecución en local)

> Antes de ejecutar la aplicación se debe modificar el archivo llamado appSettings.json en la sección **ConnectionStrings**, actualizando el servidor, usuario y clave de base de datos
```json
  "ConnectionStrings": {
    "PGPICConnection": "Server=<<Tu Servidor>>;Initial Catalog=PGPIC;Encrypt=False;User Id=<<Tu Usiario>>; Password=<<Tu Contraseña>>"
  }
```

##### Vista preliminar del swagger añadiendo un controlador fake (validando la actualización exitosa por medio del pipeline)
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/b9c39d5c-e27c-4325-befc-461a945e55a9)

##### Vista preliminar de la web desplegado en Azure
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/5f1018d9-e820-42da-945b-7ac8c86ff5f1)

##### Vista preliminar del release por medio del pipelin
![image](https://github.com/dtarenas/Entrega2.PGPIC/assets/42014718/debfc5a0-de9a-41de-8de8-9d12c9cde14b)



