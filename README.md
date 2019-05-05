# relaunch-service
Aplicación de consola para validar si un servicio de windows está detenido y volver a ejecutarlo; hecho en .net core

## Configurar la ejecución
- Abrir _Relaunch Service.dll.config_ y establecer los valores de `SERVICE_LIST` y `SERVICE_LAUNCH_TIMEOUT`. Recordá lo siguiente:
  - `SERVICE_LIST` es la lista de nombres de los servicios que van a ser ejecutados (separados por ;).
  - `SERVICE_LAUNCH_TIMEOUT` es la cantidad de milisegundos que la aplicación va a esperar para cerciorarse que el servicio inició correctamente.

## Modo de uso
1. _Single use_
    - Ejecutar _Relaunch Service.exe_ como administrador
2. _Batch_
    - Crear tarea programada en [Windows](https://www.digitalcitizen.life/use-task-scheduler-launch-programs-without-uac-prompts)
