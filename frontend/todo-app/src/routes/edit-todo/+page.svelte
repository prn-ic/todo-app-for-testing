<script>
    import { page } from '$app/stores';
    const putDataModel = {
        id: $page.url.searchParams.get('id'),
        name: '',
        description: '',
        statusId: ''
    }

    function putData () {
        var response = fetch("https://localhost:7242/v1/assignment/", {
            method: "PUT",
      headers: {
        'Content-Type': 'application/json'
      },
         body: JSON.stringify(putDataModel)
        })
    .then(response => response.json())
    .then(result => console.log(result))
    }

</script>

<h1>Edit todo</h1>

<form>
<div class="edit-todo">
    <div>
        <label for="name">Name: </label>
        <input type="text" id="name" bind:value={putDataModel.name}/>
    </div>
    <div>
        <label for="description">Description: </label>
        <input type="text" id="description" bind:value={putDataModel.description}/>
    </div>
    <div>
        <label for="statusId">StatusId: </label>
        <input type="text" id="statusId" bind:value={putDataModel.statusId}/>
    </div>

    <button on:click={putData}>Add</button>
</div>
</form>
