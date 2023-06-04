using System;
using System.Collections.Generic;
using System.Linq;

public static class EventBus
{
    private static readonly Dictionary<Type, List<WeakReference<IBaseEventReceiver>>> _receiversMap = new();
    private static readonly Dictionary<string, WeakReference<IBaseEventReceiver>> _receiverHashToReferenceMap = new();

    public static void Subscribe<T>(IEventReceiver<T> receiver) where T : struct, IEvent
    {
        Type eventType = typeof(T);
        if (!_receiversMap.ContainsKey(eventType))
            _receiversMap[eventType] = new List<WeakReference<IBaseEventReceiver>>();

        if (!_receiverHashToReferenceMap.TryGetValue(receiver.Id, out WeakReference<IBaseEventReceiver> reference))
        {
            reference = new WeakReference<IBaseEventReceiver>(receiver);
            _receiverHashToReferenceMap[receiver.Id] = reference;
        }

        _receiversMap[eventType].Add(reference);
    }

    public static void Unsubscribe<T>(IEventReceiver<T> receiver) where T : struct, IEvent
    {
        Type eventType = typeof(T);
        if (!_receiversMap.ContainsKey(eventType) || !_receiverHashToReferenceMap.ContainsKey(receiver.Id))
            return;

        WeakReference<IBaseEventReceiver> reference = _receiverHashToReferenceMap[receiver.Id];

        _receiversMap[eventType].Remove(reference);

        int weakRefCount = _receiversMap.SelectMany(x => x.Value).Count(x => x == reference);
        if (weakRefCount == 0)
            _receiverHashToReferenceMap.Remove(receiver.Id);
    }

    public static void Raise<T>(T @event) where T : struct, IEvent
    {
        Type eventType = typeof(T);
        if (!_receiversMap.ContainsKey(eventType))
            return;

        List<WeakReference<IBaseEventReceiver>> references = _receiversMap[eventType];
        for (int i = references.Count - 1; i >= 0; i--)
        {
            if (references[i].TryGetTarget(out IBaseEventReceiver receiver))
                ((IEventReceiver<T>)receiver).OnEvent(@event);
        }
    }
}