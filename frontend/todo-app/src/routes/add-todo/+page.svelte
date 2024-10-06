<script>
    const postDataModel = {
        name: '',
        description: '',
        statusId: ''
    }

    function postData () {
        var response = fetch("https://localhost:7242/v1/assignment/", {
            method: "POST",
      headers: {
        'Content-Type': 'application/json'
      },
         body: JSON.stringify(postDataModel)
        })
    .then(response => response.json())
    .then(result => console.log(result))
    }

</script>

<h1>Add todo</h1>

<form>
<div class="add-todo">
    <div>
        <label for="name">Name: </label>
        <input type="text" id="name" bind:value={postDataModel.name}/>
    </div>
    <div>
        <label for="description">Description: </label>
        <input type="text" id="description" bind:value={postDataModel.description}/>
    </div>
    <div>
        <label for="statusId">StatusId: </label>
        <input type="text" id="statusId" bind:value={postDataModel.statusId}/>
    </div>

    <button on:click={postData}>Add</button>
</div>
</form>
