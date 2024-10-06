<script>
  import { page } from '$app/stores';

  let queryParam;

  $: queryParam = $page.url.searchParams.get('id');

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
{#await getAllTodosPromise}
    <h2>Loading...</h2>
{:then todos}
  <div class="todos__todo">
      <p class="todos__todo_name">{todos[queryParam].name}</p>
      <br/>
      <a href="/edit-todo?id={todos[queryParam].id}">edit</a>
      <a href="/remove-todo?id={todos[queryParam].id}" style="color: red">remove</a>
      <hr/>
      <p>{todos[queryParam].description}</p>
      <p>Status: {todos[queryParam].status.name}</p>
  </div>
{:catch error}
    <h1>error while loading your todo</h1>
{/await}