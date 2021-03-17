$(".hand-card").draggable({
  revert: true,
});
$(".board .your-side").droppable({
  drop: function (event, ui) {
    var src = $(ui.draggable).find("img").attr("src");
    var id = $(ui.draggable).data("id");
    var newDiv = `<div class="board-card"><img data-id='${id}'  src='${src}'/></div>`;
    $(this).append(newDiv);
    $(ui.draggable).remove();
    $(".board .your-side .board-card").draggable({
      revert: "valid",
      containment: ".board",
    });
  },
});

$(".board .opponent-side").droppable();
$(".board .opponent-side .board-card").droppable({
  greedy: true,
  accept:".board-card",
  drop: function (event, ui) {
    alert($(this).data("id"));
  },
});

$("#monsterDeck").on("click", () => {
  $("#monsterDeck").addClass("swing-left-fwd");

  setTimeout(() => {
    $(".hand").append(
      `<div data-id="card1" class="hand-card"><img src="https://ygoprodeck.com/pics/55144522.jpg" /></div>`
    );
    $(".hand-card").draggable({
      revert: true,
    });
    $("#monsterDeck").removeClass("swing-left-fwd");
  }, 1050);
});
