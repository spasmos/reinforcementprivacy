# Titulo

ReinforcementPrivacy

## Descripcion Corta

Un mod server-side de privacidad para Vintage Story que anonimiza los nombres legibles de jugadores y grupos en los datos de refuerzo de bloques.

## Descripcion Larga

`ReinforcementPrivacy` es un mod server-side de privacidad para el sistema de refuerzos de bloques de Vintage Story 1.22.x.

Esta pensado para servidores PvP, facciones, roleplay y servidores centrados en privacidad donde los bloques reforzados o bloqueados no deberian revelar informacion gratuita sobre quien los posee.

En vanilla, los bloques reforzados o bloqueados pueden exponer informacion legible del propietario mediante los datos del refuerzo, como el ultimo nombre de jugador o el nombre del grupo asociado. Este mod cambia ese comportamiento en el servidor anonimizando esos nombres legibles antes de guardar y sincronizar los datos de refuerzo con los clientes.

El mod conserva intactos los datos funcionales de propiedad:

- `PlayerUID` se conserva
- `GroupUid` se conserva
- La resistencia del refuerzo se conserva
- El estado de bloqueo se conserva
- Los datos del objeto usado para bloquear se conservan

Solo se sustituyen los nombres visibles:

- `LastPlayername` pasa a ser `Unknown`
- `LastGroupname` pasa a ser `Unknown group`

Esto significa que la propiedad y los permisos vanilla de los refuerzos deberian seguir funcionando normalmente, mientras que los clientes ya no reciben los nombres reales visibles de jugadores o grupos por esta ruta de datos del sistema de refuerzos.

## Relacion con HideLockerAndReinforcerName

Este mod se creo despues de hablar la idea con SiiMeR y parte del objetivo de privacidad del mod original `HideLockerAndReinforcerName`:

https://mods.vintagestory.at/show/mod/36662

El mod original se centra en ocultar la informacion del propietario en el tooltip mostrado al inspeccionar el bloque.

`ReinforcementPrivacy` aplica un enfoque server-side mas estricto: anonimiza los nombres legibles de jugadores y grupos en los datos de refuerzo antes de que esos datos se guarden y se sincronicen con los clientes, conservando al mismo tiempo los IDs internos necesarios para que los permisos vanilla sigan funcionando.

Ambos enfoques pueden ser utiles segun el servidor. Usa el mod original si solo necesitas ocultacion a nivel de tooltip. Usa este mod si quieres sanear los nombres legibles de propietarios de refuerzos en la capa de sincronizacion de datos del servidor.

## Notas Importantes

- Solo se ejecuta en el servidor
- Los clientes no necesitan instalarlo
- Afecta solo al sistema de refuerzos de bloques
- No oculta nombres de jugadores en chat, mapas, nametags, logs, reclamaciones de terreno ni herramientas de administracion
- Los refuerzos existentes se anonimizan cuando el juego reescribe o sincroniza esos datos de refuerzo

## Instrucciones de Uso

1. Instala el mod en el servidor.
2. Reinicia el servidor.
3. Los nuevos datos de refuerzo se guardaran y sincronizaran sin nombres legibles de propietario o grupo.

Prueba recomendada tras la instalacion:

1. Refuerza o bloquea un bloque con un jugador.
2. Inspeccionalo con otro jugador.
3. Confirma que el tooltip no expone el propietario o grupo original.
4. Confirma que el propietario legitimo puede seguir quitando o gestionar el refuerzo.

Compatibilidad:

- Vintage Story `1.22.x`

## Creditos

- Autor: `spasmos`
- Contribuidor: `SiiMeR`
- Basado en el objetivo de privacidad de `HideLockerAndReinforcerName` de SiiMeR

## Changelog 1.0.0

- Primera release como `ReinforcementPrivacy`
- Renombrada la identidad del proyecto y del mod para evitar confusion con el mod original
- Anadidos creditos explicitos y notas de relacion con `HideLockerAndReinforcerName`
- Conservado el enfoque mas estricto de anonimizacion server-side de datos de refuerzo
- Conservados `PlayerUID` y `GroupUid` para que la propiedad y permisos vanilla puedan seguir funcionando
- Sustituidos los nombres legibles de propietarios de refuerzos por valores neutrales antes del guardado y la sincronizacion de red
- Marcado el mod como server-side para que los clientes no tengan que instalarlo
