<!-- Generator: Widdershins v4.0.1 -->

<h1 id="eventmanager-version-1-0-0-0-culture-neutral-publickeytoken-null">EventManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null v1.0</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

<h1 id="eventmanager-version-1-0-0-0-culture-neutral-publickeytoken-null-events">Events</h1>

## get__api_Events

> Code samples

```shell
# You can also use wget
curl -X GET /api/Events \
  -H 'Accept: text/plain'

```

```http
GET /api/Events HTTP/1.1

Accept: text/plain

```

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
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Возвращается JSON-структура `ApiResult<List<EventResponseDto>>` со списком событий
            и HTTP статус-кодом `200 Ok` в случае успеха|[EventResponseDtoListApiResult](#schemaeventresponsedtolistapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## post__api_Events

> Code samples

```shell
# You can also use wget
curl -X POST /api/Events \
  -H 'Content-Type: application/json' \
  -H 'Accept: text/plain'

```

```http
POST /api/Events HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

`POST /api/Events`

*Метод создает новое событие*

> Body parameter

```json
{
  "title": "string",
  "description": "string",
  "startAt": "2019-08-24T14:15:22Z",
  "endAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="post__api_events-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[EventRequestDto](#schemaeventrequestdto)|false|Набор данных необходимых для создания нового события|

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
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Возвращается JSON-структура `ApiResult<EventResponseDto>` с созданым событием
            и HTTP статус-кодом `201 Created` в случае успеха|[BooleanApiResult](#schemabooleanapiresult)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Возвращается JSON-структура `ApiResult<EventResponseDto>` без события
            и HTTP статус-кодом `400 BadRequest` в случае не удачи|[BooleanApiResult](#schemabooleanapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_Events_{id}

> Code samples

```shell
# You can also use wget
curl -X GET /api/Events/{id} \
  -H 'Accept: text/plain'

```

```http
GET /api/Events/{id} HTTP/1.1

Accept: text/plain

```

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
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Возвращается JSON-структура `ApiResult<EventResponseDto>` с информацией о событии
            и HTTP статус-кодом `200 Ok` в случае успеха|[EventResponseDtoApiResult](#schemaeventresponsedtoapiresult)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Возвращается JSON-структура `ApiResult<EventResponseDto>` с сообщением о том что событие не найдено
            и HTTP статус-кодом `404 NotFound` в случае не удачи|[EventResponseDtoApiResult](#schemaeventresponsedtoapiresult)|

<aside class="success">
This operation does not require authentication
</aside>

## put__api_Events_{id}

> Code samples

```shell
# You can also use wget
curl -X PUT /api/Events/{id} \
  -H 'Content-Type: application/json' \
  -H 'Accept: text/plain'

```

```http
PUT /api/Events/{id} HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

`PUT /api/Events/{id}`

*Метод обновляет сущевствующее событие*

> Body parameter

```json
{
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
|body|body|[EventRequestDto](#schemaeventrequestdto)|false|Набор данных необходимых для обновления сущевствующего события|

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

```shell
# You can also use wget
curl -X DELETE /api/Events/{id} \
  -H 'Accept: text/plain'

```

```http
DELETE /api/Events/{id} HTTP/1.1

Accept: text/plain

```

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

<h2 id="tocS_EventRequestDto">EventRequestDto</h2>
<!-- backwards compatibility -->
<a id="schemaeventrequestdto"></a>
<a id="schema_EventRequestDto"></a>
<a id="tocSeventrequestdto"></a>
<a id="tocseventrequestdto"></a>

```json
{
  "title": "string",
  "description": "string",
  "startAt": "2019-08-24T14:15:22Z",
  "endAt": "2019-08-24T14:15:22Z"
}

```

DTO входной модели события

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|title|string|true|none|Название события|
|description|string|true|none|Описание события|
|startAt|string(date-time)¦null|false|none|Начало события|
|endAt|string(date-time)¦null|false|none|Конец события|

<h2 id="tocS_EventResponseDto">EventResponseDto</h2>
<!-- backwards compatibility -->
<a id="schemaeventresponsedto"></a>
<a id="schema_EventResponseDto"></a>
<a id="tocSeventresponsedto"></a>
<a id="tocseventresponsedto"></a>

```json
{
  "id": 0,
  "title": "string",
  "description": "string",
  "startAt": "2019-08-24T14:15:22Z",
  "endAt": "2019-08-24T14:15:22Z"
}

```

DTO выходной модели события

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|false|none|Id события|
|title|string|true|none|Название события|
|description|string|true|none|Описание события|
|startAt|string(date-time)¦null|false|none|Начало события|
|endAt|string(date-time)¦null|false|none|Конец события|

<h2 id="tocS_EventResponseDtoApiResult">EventResponseDtoApiResult</h2>
<!-- backwards compatibility -->
<a id="schemaeventresponsedtoapiresult"></a>
<a id="schema_EventResponseDtoApiResult"></a>
<a id="tocSeventresponsedtoapiresult"></a>
<a id="tocseventresponsedtoapiresult"></a>

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
|data|[EventResponseDto](#schemaeventresponsedto)|true|none|DTO выходной модели события|

<h2 id="tocS_EventResponseDtoListApiResult">EventResponseDtoListApiResult</h2>
<!-- backwards compatibility -->
<a id="schemaeventresponsedtolistapiresult"></a>
<a id="schema_EventResponseDtoListApiResult"></a>
<a id="tocSeventresponsedtolistapiresult"></a>
<a id="tocseventresponsedtolistapiresult"></a>

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
|data|[[EventResponseDto](#schemaeventresponsedto)]¦null|true|none|Результат работы запроса|

