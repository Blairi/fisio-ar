# FisioAR - Asistente Virtual de Fisioterapia en Realidad Aumentada

FisioAR es una aplicación móvil de Realidad Aumentada (RA) desarrollada en **Unity** utilizando el SDK de **Vuforia Engine**. El sistema funciona como un entrenador personal virtual diseñado para guiar a los usuarios en la ejecución correcta de rutinas de fisioterapia, rehabilitación ligera y corrección postural preventiva mediante la proyección de un avatar 3D animado en un entorno real.

---

## 🚀 Características Principales

- **Bifurcación de Rutinas por Intensidad:** Evalúa el nivel de dolor del usuario mediante un *Slider* digital (escala 1-10) para generar automáticamente una rutina personalizada de intensidad Baja, Media o de Recuperación pasiva.
- **Cuestionario de Corrección Postural:** Módulo enfocado en la prevención de lesiones causadas por hábitos cotidianos (trabajo en computadora, uso de celular, postura al estar sentado, espalda encorvada).
- **Persistencia de Datos Orientada a Objetos:** Implementación de un modelo de datos desacoplado (`Routine` y `Exercise`) transferido eficientemente entre escenas a través de un contenedor estático global (`SessionData`).
- **Seguimiento Físico Robusto (*Image Tracking*):** Anclaje espacial del avatar tridimensional a un marcador físico (*Image Target*), reaccionando en tiempo real a la pérdida o ganancia de rastreo de la cámara.
- **Motor de Ejecución y Cronometría:** Control temporal secuencial de los ejercicios mediante corrutinas de cuenta regresiva (3, 2, 1), temporizador dinámico basado en repeticiones y controles interactivos de pausa, reanudación y reinicio.
- **Paginación Amigable:** Pantallas de transición intermedia entre ejercicios ("¿Desea continuar al siguiente ejercicio?") para respetar el ritmo de descanso y preparación del paciente.
- **Máquina de Estados Eficiente:** Controlador de animación (`Animator Controller`) optimizado con el nodo *Any State* y configurado con un Rig de tipo *Humanoid*, permitiendo transiciones inmediatas y fluidas sin interrupciones o congelamiento visual.

---

## 🛠️ Arquitectura del Software (Módulos Core)

La aplicación aplica el **Principio de Responsabilidad Única (SRP)** y se estructura en las siguientes capas de control distribuidas en un GameObject centralizado (`ARController`):

1. **`SessionData.cs` / `RoutineModels.cs` (Capa de Persistencia/DTO):** Clases puras de C# que modelan la estructura de las rutinas y actúan como puente de memoria ramificada entre el menú principal y el entorno de Realidad Aumentada.
2. **`ARSessionManager.cs` (Orquestador de Sesión):** Captura los eventos de hardware de Vuforia (`OnTargetFound` / `OnTargetLost`) y coordina el flujo lógico inicial inyectando los datos almacenados en el manejador de interfaz.
3. **`ARUIManager.cs` (Capa de Presentación):** Script desacoplado encargado exclusivamente de la activación/desactivación de paneles del Canvas (Escaneo, Info, Conteo, Ejercicio Activo, Transición, Finalización) y actualización de textos en *TextMeshPro*.
4. **`RoutineExecutionManager.cs` (Motor de Tiempos):** Administra el cronómetro en el bucle `Update`, dispara secuencialmente los *Triggers* de animación del modelo 3D y procesa las acciones de pausa, continuación y restablecimiento de la rutina.

---

## 📁 Estructura del Proyecto (Assets)


```

```text
README.md generated successfully.

```text
Assets/
│
├── _Project/
│   ├── Scenes/
│   │   ├── MenuPrincipal.unity       # UI de configuración, sliders y cuestionarios
│   │   └── MainScene.unity           # Escena de Realidad Aumentada (Vuforia)
│   │
│   ├── Scripts/
│   │   ├── RoutineModels.cs          # Modelos de datos de Ejercicios y Rutinas
│   │   ├── SessionData.cs            # Clase estática global de persistencia
│   │   ├── RoutineManager.cs         # Gestor del flujo de rehabilitación por dolor
│   │   ├── PostureManager.cs         # Gestor del cuestionario postural preventivo
│   │   ├── ARSessionManager.cs       # Interceptor de eventos Vuforia
│   │   ├── ARUIManager.cs            # Controlador visual de pantallas de AR
│   │   └── RoutineExecutionManager.cs # Motor del temporizador y animaciones
│   │
│   ├── Animations/
│   │   ├── FisioAvatarController.controller # Máquina de estados (Animator)
│   │   └── *.fbx                     # Archivos de animación (Mixamo Humanoid)
│   │
│   └── Prefabs/                      # Avatar 3D configurado y Image Targets

```

---

## 🔧 Requisitos e Instalación

### Prerrequisitos

* **Unity Editor:** Versión 2022.3 LTS o superior recomendada.
* **Vuforia Engine SDK:** Importado e integrado en el proyecto.
* **Dispositivo de pruebas:** Dispositivo Android o iOS con cámara funcional y soporte para AR, o cámara web para pruebas en el editor.

### Configuración del Repositorio

1. Clona este repositorio en tu máquina local:
```bash
git clone [https://github.com/tu-usuario/FisioAR.git](https://github.com/tu-usuario/FisioAR.git)

```


2. Abre **Unity Hub** y añade el proyecto clonado.
3. Asegúrate de tener configurada tu clave de licencia de Vuforia en `Window > Vuforia Configuration`.
4. Abre la escena `MenuPrincipal.unity` ubicada en la carpeta de escenas.
5. Presiona **Play** para realizar pruebas en el editor utilizando tu cámara web apuntando al *Image Target* correspondiente, o realiza el *Build* directo a tu dispositivo móvil (*Android/iOS*).

---

## ⚙️ Configuración del Animator Controller (Triggers)

Para expandir o emparejar nuevas animaciones con el avatar, asegúrate de dar de alta los siguientes parámetros de tipo **Trigger** en la pestaña *Parameters* del Animator de Unity, los cuales deben coincidir exactamente con las cadenas de texto del script:

* **Base:** `Anim_Idle`
* **Postura:** `Anim_PelvicTilt`, `Anim_HamstringStretch`, `Anim_ThoracicRotation`, `Anim_ChinTuck`, `Anim_TrapStretch`, `Anim_ShoulderMobility`, `Anim_CobraPose`, `Anim_ScapularRetraction`, `Anim_PecDoorwayStretch`, `Anim_CervicalRetraction`, `Anim_ShoulderOpening`, `Anim_ScapularCorrection`.
* **Rodilla:** `Anim_KneeFlexion`, `Anim_KneeExtension`, `Anim_GuidedRest`, `Anim_IsometricSquats`, `Anim_LegLift`, `Anim_CalfStretch`, `Anim_AnkleMovements`, `Anim_HeelSlide`.
* **Cuello:** `Anim_LateralNeckTilt`, `Anim_NeckRotation`, `Anim_NeckFlexionExtension`, `Anim_SupportedNeckStretch`, `Anim_IsometricNeckExercises`, `Anim_DiaphragmaticBreathing`, `Anim_MillimeterMovements`.

*Nota de importación: Todos los archivos de animación `.fbx` deben configurarse en la pestaña **Rig** como **Animation Type: Humanoid** y tener la propiedad **Has Exit Time** desmarcada en las transiciones desde el nodo Any State.*

---

## 📝 Licencia

Este proyecto fue desarrollado con fines académicos y de investigación en ingeniería de software y salud.