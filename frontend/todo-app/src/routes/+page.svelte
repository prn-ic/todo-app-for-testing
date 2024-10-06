<script>
    const getAllTodos = async () => {
        var response = await fetch("https://localhost:7242/v1/assignment");
        var result = await response.json();
        console.log(result);
        return result;
    }

    let getAllTodosPromise = getAllTodos();
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

<h1>Welcome to Todos</h1>
<p>There is you have check all your todos</p>
<a href="/add-todo">Add todo</a>

<div class="todos">
{#await getAllTodosPromise}
    <h2>Loading...</h2>
{:then todos}
{#each todos as todo (todo.id)}
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
{:catch error}
    <h1>error while loading your todo</h1>
{/await}

</div>