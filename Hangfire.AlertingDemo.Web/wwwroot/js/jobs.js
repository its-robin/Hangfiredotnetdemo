async function postJson(url, body){
  const res = await fetch(url, {
    method: 'POST',
    headers: {'Content-Type':'application/json'},
    body: JSON.stringify(body)
  });
  return res.json();
}
function append(msg){ const out = document.getElementById('output'); out.innerText += msg + '\n'; }
document.getElementById('btn-fire').addEventListener('click', async ()=>{
  const r = await postJson('/api/jobs/fire-and-forget',{ to:'user@example.com', subject:'Hello from Hangfire', body:'This is a demo' });
  append('Fire job queued: ' + r.jobId);
});
document.getElementById('btn-delayed').addEventListener('click', async ()=>{
  const r = await postJson('/api/jobs/delayed',{ to:'user@example.com', subject:'Delayed', body:'This is delayed', delaySeconds:10 });
  append('Delayed job scheduled: ' + r.jobId);
});
document.getElementById('btn-cont').addEventListener('click', async ()=>{
  const r = await postJson('/api/jobs/continuation',{ message:'Important alert' });
  append('Continuation created. Parent: ' + r.parentId + ' Cont: ' + r.continuationId);
});
document.getElementById('btn-recurring').addEventListener('click', async ()=>{
  const r = await postJson('/api/jobs/recurring',{});
  append('Recurring job enabled: ' + r.recurringId);
});
