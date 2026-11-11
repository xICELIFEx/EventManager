<!-- Generator: Widdershins v4.0.1 -->

<h1 id="eventmanager-version-1-0-0-0-culture-neutral-publickeytoken-null">EventManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null v1.0</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

<h1 id="eventmanager-version-1-0-0-0-culture-neutral-publickeytoken-null-events">Events</h1>

## get__api_Events

> Code samples

`GET /api/Events`

*Метод возвращает информацию обо всех хранящихся событиях*

> Example responses

> 200 Response

```
{"message":"string","data":[{"id":0,"title":"string","description":"string","startAt":"2019-08-24T14:15:22Z","endAt":"2019-08-24T14:15:22Z"}]}
```

```json
{
  "message": "string",
  "data": [
    {
      "id": 0,
      "title": "string",
      "description": "string",
      "startAt": "2019-08-24T14:15:22Z",
      "endAt": "2019-08-24T14:15:22Z"
    }
  ]
}
```

<h3 id="get__api_events-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Возвращается JSON-структура `ApiResult<List<EventDto>>` со списком событий
            и HTTP статус-кодом `200 Ok` в случае успеха|[EventDtoListApiResult](#schemaeventdtolistapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## post__api_Events

> Code samples

`POST /api/Events`

*Метод создает новое событие*

> Body parameter

```json
{
  "id": 0,
  "title": "string",
  "description": "string",
  "startAt": "2019-08-24T14:15:22Z",
  "endAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="post__api_events-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[EventDto](#schemaeventdto)|false|Набор данных необходимых для создания нового события|

> Example responses

> 201 Response

```
{"message":"string","data":true}
```

```json
{
  "message": "string",
  "data": true
}
```

<h3 id="post__api_events-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Возвращается JSON-структура `ApiResult<bool>` с флагом создано событие или нет
            и HTTP статус-кодом `201 Created` в случае успеха|[BooleanApiResult](#schemabooleanapiresult)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Возвращается JSON-структура `ApiResult<bool>` с флагом создано событие или нет
            и HTTP статус-кодом `400 BadRequest` в случае не удачи|[BooleanApiResult](#schemabooleanapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_Events_{id}

> Code samples

`GET /api/Events/{id}`

*Метод возвращает информацию о событии по его id*

<h3 id="get__api_events_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|Параметр id, для получения информации о связанном событии|

> Example responses

> 200 Response

```
{"message":"string","data":{"id":0,"title":"string","description":"string","startAt":"2019-08-24T14:15:22Z","endAt":"2019-08-24T14:15:22Z"}}
```

```json
{
  "message": "string",
  "data": {
    "id": 0,
    "title": "string",
    "description": "string",
    "startAt": "2019-08-24T14:15:22Z",
    "endAt": "2019-08-24T14:15:22Z"
  }
}
```

<h3 id="get__api_events_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Возвращается JSON-структура `ApiResult<EventDto>` с информацией о событии
            и HTTP статус-кодом `200 Ok` в случае успеха|[EventDtoApiResult](#schemaeventdtoapiresult)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Возвращается JSON-структура `ApiResult<EventDto>` с сообщением о том что событие не найдено
            и HTTP статус-кодом `404 NotFound` в случае не удачи|[EventDtoApiResult](#schemaeventdtoapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## put__api_Events_{id}

> Code samples

`PUT /api/Events/{id}`

*Метод обновляет сущевствующее событие*

> Body parameter

```json
{
  "id": 0,
  "title": "string",
  "description": "string",
  "startAt": "2019-08-24T14:15:22Z",
  "endAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="put__api_events_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|Параметр id, указывает на обновляемое событие|
|body|body|[EventDto](#schemaeventdto)|false|Набор данных необходимых для обновления сущевствующего события|

> Example responses

> 200 Response

```
{"message":"string","data":true}
```

```json
{
  "message": "string",
  "data": true
}
```

<h3 id="put__api_events_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Возвращается JSON-структура `ApiResult<bool>` с флагом обновлено событие или нет
            и HTTP статус-кодом `200 Ok` в случае успеха|[BooleanApiResult](#schemabooleanapiresult)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Возвращается JSON-структура `ApiResult<bool>` с флагом обновлено событие или нет
            и HTTP статус-кодом `404 NotFound` в случае не удачи|[BooleanApiResult](#schemabooleanapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## delete__api_Events_{id}

> Code samples

`DELETE /api/Events/{id}`

*Метод удаляет сущевствующее событие*

<h3 id="delete__api_events_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|Индекс удаляемого события|

> Example responses

> 200 Response

```
{"message":"string","data":true}
```

```json
{
  "message": "string",
  "data": true
}
```

<h3 id="delete__api_events_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Возвращается JSON-структура `ApiResult<bool>` с флагом обновлено событие или нет
            и HTTP статус-кодом `200 Ok` в случае успеха|[BooleanApiResult](#schemabooleanapiresult)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Возвращается JSON-структура `ApiResult<bool>` с флагом обновлено событие или нет
            и HTTP статус-кодом `404 NotFound` в случае не удачи|[BooleanApiResult](#schemabooleanapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_BooleanApiResult">BooleanApiResult</h2>
<!-- backwards compatibility -->
<a id="schemabooleanapiresult"></a>
<a id="schema_BooleanApiResult"></a>
<a id="tocSbooleanapiresult"></a>
<a id="tocsbooleanapiresult"></a>

```json
{
  "message": "string",
  "data": true
}

```

Класс результата с данными полученными в результате выполнения запроса

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|message|string¦null|true|none|Кастомное сообщение с дополнительной информацией<br>Здесь может быть информация об ошибке в случае неуспеха|
|data|boolean|true|none|Результат работы запроса|

<h2 id="tocS_EventDto">EventDto</h2>
<!-- backwards compatibility -->
<a id="schemaeventdto"></a>
<a id="schema_EventDto"></a>
<a id="tocSeventdto"></a>
<a id="tocseventdto"></a>

```json
{
  "id": 0,
  "title": "string",
  "description": "string",
  "startAt": "2019-08-24T14:15:22Z",
  "endAt": "2019-08-24T14:15:22Z"
}

```

DTO модели события

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|false|none|Id события|
|title|string|true|none|Название события|
|description|string|true|none|Описание события|
|startAt|string(date-time)¦null|false|none|Начало события|
|endAt|string(date-time)¦null|false|none|Конец события|

<h2 id="tocS_EventDtoApiResult">EventDtoApiResult</h2>
<!-- backwards compatibility -->
<a id="schemaeventdtoapiresult"></a>
<a id="schema_EventDtoApiResult"></a>
<a id="tocSeventdtoapiresult"></a>
<a id="tocseventdtoapiresult"></a>

```json
{
  "message": "string",
  "data": {
    "id": 0,
    "title": "string",
    "description": "string",
    "startAt": "2019-08-24T14:15:22Z",
    "endAt": "2019-08-24T14:15:22Z"
  }
}

```

Класс результата с данными полученными в результате выполнения запроса

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|message|string¦null|true|none|Кастомное сообщение с дополнительной информацией<br>Здесь может быть информация об ошибке в случае неуспеха|
|data|[EventDto](#schemaeventdto)|true|none|DTO модели события|

<h2 id="tocS_EventDtoListApiResult">EventDtoListApiResult</h2>
<!-- backwards compatibility -->
<a id="schemaeventdtolistapiresult"></a>
<a id="schema_EventDtoListApiResult"></a>
<a id="tocSeventdtolistapiresult"></a>
<a id="tocseventdtolistapiresult"></a>

```json
{
  "message": "string",
  "data": [
    {
      "id": 0,
      "title": "string",
      "description": "string",
      "startAt": "2019-08-24T14:15:22Z",
      "endAt": "2019-08-24T14:15:22Z"
    }
  ]
}

```

Класс результата с данными полученными в результате выполнения запроса

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|message|string¦null|true|none|Кастомное сообщение с дополнительной информацией<br>Здесь может быть информация об ошибке в случае неуспеха|
|data|[[EventDto](#schemaeventdto)]¦null|true|none|Результат работы запроса|

