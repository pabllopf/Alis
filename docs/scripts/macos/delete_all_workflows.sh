# ejemplo en bash usando curl
TOKEN=""
OWNER="pabllopf"
REPO="Alis"
PER_PAGE=100  # número máximo de runs por página

PAGE=1
while true; do
  echo "Fetching page $PAGE..."
  # obtenemos los workflow runs de esta página
  runs=$(curl -s -H "Authorization: token $TOKEN" \
    "https://api.github.com/repos/$OWNER/$REPO/actions/runs?per_page=$PER_PAGE&page=$PAGE" \
    | jq -r '.workflow_runs[].id')

  # si no hay runs, terminamos
  if [ -z "$runs" ]; then
    echo "No more runs found. Done!"
    break
  fi

  # borramos cada run
  for run_id in $runs; do
    echo "Deleting run $run_id..."
    response=$(curl -s -o /dev/null -w "%{http_code}" -X DELETE \
      -H "Authorization: token $TOKEN" \
      "https://api.github.com/repos/$OWNER/$REPO/actions/runs/$run_id")

    if [ "$response" -eq 204 ]; then
      echo "✅ Deleted run $run_id"
    else
      echo "⚠️ Could not delete run $run_id (HTTP $response), skipping..."
    fi
  done

  PAGE=$((PAGE+1))
done