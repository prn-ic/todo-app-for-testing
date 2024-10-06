<script>
    const filterModel = {
        name: '',
        statusId: '0'
    }
    $: filteredTodos = []
    async function getTodos() {
        var response = await fetch("https://localhost:7242/v1/assignment/filter?" + "name=" + filterModel.name + "&statusId=" + filterModel.statusId);
        var result = await response;
        filteredTodos = await result.json();

        console.log(await result.json());
        console.log(filteredTodos)
    }

</script>
<style>
    .todos__todo {
        padding: 5px;
        border: 1px solid black;
        width: 130px;
    }

    .todos__todo_name {
        font-weight: bold;
        margin: 0
    }
</style>

<h1>Search to Todos</h1>
<p>There is you have check your todos</p>
<a href="/add-todo">Add todo</a>

<form>
    <div>
        <div>
            <label for="name">Name:</label>
            <input type="text" id="name" bind:value={filterModel.name}/>
        </div>
        <div>
            <label for="statusId">StatusId:</label>
            <input type="text" id="statusId" bind:value={filterModel.statusId}/>
        </div>
    </div>

    <button on:click={getTodos}>Search</button>
</form>

<div class="todos">
{#each filteredTodos as todo (todo.id)}
    <div class="todos__todo">
        <a href="/todo?id={todo.id}" class="todos__todo_name">{todo.name}</a>
        <br/>
        <a href="/edit-todo?id={todo.id}">edit</a>
        <a href="/remove-todo?id={todo.id}" style="color: red">remove</a>
        <hr/>
        <p>{todo.description}</p>
        <p>Status: {todo.status.name}</p>
    </div>
{/each}

</div>